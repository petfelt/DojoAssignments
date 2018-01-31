import { browser, element, by } from 'protractor';

export class RouteAndSubroutesPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('app-root h1')).getText();
  }
}
