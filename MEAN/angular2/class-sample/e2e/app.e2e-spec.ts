import { ClassSamplePage } from './app.po';

describe('class-sample App', () => {
  let page: ClassSamplePage;

  beforeEach(() => {
    page = new ClassSamplePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
