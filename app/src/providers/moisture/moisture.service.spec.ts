import { configure, Context } from 'rxjs-marbles/jasmine';
import { MoistureService } from './moisture.service';
import { IMock, It, Mock, Times } from 'typemoq';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable, SchedulerLike } from 'rxjs';
import { TestScheduler } from 'rxjs/testing';
const { marbles } = configure({ run: false });

describe('MoistureServiceTests', () => {

  let service: MoistureService;
  let httpClient: IMock<HttpClient>;

  beforeEach(() => {
    httpClient = Mock.ofType<HttpClient>();
    service = new MoistureService(httpClient.object);
  });

  it('', marbles(m => {

    // Arrange
    m.bind();
    m.flush();

    http(m, '-----r|');

    // Act
    const actual = getMoisture(m.scheduler);

    // Assert
    assertResult(m, actual, '------m|');
  }));

  function http(m: Context, result: string) {
    const obs = m.cold(result, { r: new ArrayBuffer(10) });
    httpClient.setup(x => x.get(It.isAny(), It.isAny())).returns(() => {
      return obs;
    });
  }

  function getMoisture(scheduler: TestScheduler) {
    return service.getMoisture(scheduler).pipe(
      map(x => {
        if (x != null) { return 'm'; }
      })
    );
  }

  function assertResult(m: Context, actual: Observable<any>, results: string) {
    m.expect(actual).toBeObservable(results);
  }
});
