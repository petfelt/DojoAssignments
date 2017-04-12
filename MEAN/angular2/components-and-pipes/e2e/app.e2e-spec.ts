import { ComponentsAndPipesPage } from './app.po';

describe('components-and-pipes App', () => {
  let page: ComponentsAndPipesPage;

  beforeEach(() => {
    page = new ComponentsAndPipesPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
