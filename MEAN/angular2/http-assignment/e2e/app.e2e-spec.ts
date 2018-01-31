import { HttpAssignmentPage } from './app.po';

describe('http-assignment App', () => {
  let page: HttpAssignmentPage;

  beforeEach(() => {
    page = new HttpAssignmentPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
