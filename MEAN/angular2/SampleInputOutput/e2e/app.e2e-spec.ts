import { SampleInputOutputPage } from './app.po';

describe('sample-input-output App', function() {
  let page: SampleInputOutputPage;

  beforeEach(() => {
    page = new SampleInputOutputPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
