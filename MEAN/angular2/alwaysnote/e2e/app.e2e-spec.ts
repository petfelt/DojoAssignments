import { AlwaysnotePage } from './app.po';

describe('alwaysnote App', () => {
  let page: AlwaysnotePage;

  beforeEach(() => {
    page = new AlwaysnotePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
