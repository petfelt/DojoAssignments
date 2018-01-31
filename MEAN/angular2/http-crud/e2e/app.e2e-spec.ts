import { HttpCrudPage } from './app.po';

describe('http-crud App', () => {
  let page: HttpCrudPage;

  beforeEach(() => {
    page = new HttpCrudPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
