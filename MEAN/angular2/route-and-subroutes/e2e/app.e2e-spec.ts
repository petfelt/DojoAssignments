import { RouteAndSubroutesPage } from './app.po';

describe('route-and-subroutes App', () => {
  let page: RouteAndSubroutesPage;

  beforeEach(() => {
    page = new RouteAndSubroutesPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
