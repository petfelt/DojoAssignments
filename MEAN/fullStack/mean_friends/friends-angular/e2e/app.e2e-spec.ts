import { FriendsAngularPage } from './app.po';

describe('friends-angular App', () => {
  let page: FriendsAngularPage;

  beforeEach(() => {
    page = new FriendsAngularPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
