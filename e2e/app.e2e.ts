import { InvestSystemsOrgPage } from './app.po';

describe('invest-systems-org App', function() {
  let page: InvestSystemsOrgPage;

  beforeEach(() => {
    page = new InvestSystemsOrgPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('invest-systems-org works!');
  });
});
