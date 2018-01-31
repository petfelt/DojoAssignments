import { SampleRoutingPage } from './app.po';

describe('sample-routing App', () => {
  let page: SampleRoutingPage;

  beforeEach(() => {
    page = new SampleRoutingPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
