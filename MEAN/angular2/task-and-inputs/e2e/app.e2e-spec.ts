import { TaskAndInputsPage } from './app.po';

describe('task-and-inputs App', () => {
  let page: TaskAndInputsPage;

  beforeEach(() => {
    page = new TaskAndInputsPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
