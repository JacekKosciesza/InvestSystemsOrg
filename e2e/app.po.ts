export class InvestSystemsOrgPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('invest-systems-org-app h1')).getText();
  }
}
