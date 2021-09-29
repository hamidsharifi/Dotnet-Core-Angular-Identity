import { Component, Inject, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'report-viewer',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './report-viewer.html',
})
export class ReportViewerComponent {
  reportUrl: string = "Numeric1SideTab";
  invokeAction: string = '/DXXRDV';

  constructor(@Inject('BASE_URL') public hostUrl: string) { }
}
