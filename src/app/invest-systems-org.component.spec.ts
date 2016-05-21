import {
  beforeEachProviders,
  describe,
  expect,
  it,
  inject
} from '@angular/core/testing';
import { InvestSystemsOrgAppComponent } from '../app/invest-systems-org.component';

beforeEachProviders(() => [InvestSystemsOrgAppComponent]);

describe('App: InvestSystemsOrg', () => {
  it('should create the app',
      inject([InvestSystemsOrgAppComponent], (app: InvestSystemsOrgAppComponent) => {
    expect(app).toBeTruthy();
  }));

  it('should have as title \'invest-systems-org works!\'',
      inject([InvestSystemsOrgAppComponent], (app: InvestSystemsOrgAppComponent) => {
    expect(app.title).toEqual('invest-systems-org works!');
  }));
});
