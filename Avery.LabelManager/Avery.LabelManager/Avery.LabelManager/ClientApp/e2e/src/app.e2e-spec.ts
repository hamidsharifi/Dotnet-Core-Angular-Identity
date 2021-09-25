// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { AppPage } from './app.po';

describe('Avery.LabelManager App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display application title: Avery.LabelManager', async () => {
    await page.navigateTo();
    expect(await page.getAppTitle()).toEqual('Avery.LabelManager');
  });
});
