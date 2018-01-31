import { FirstUsersPage } from './app.po';

describe('first-users App', () => {
  let page: FirstUsersPage;

  beforeEach(() => {
    page = new FirstUsersPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
