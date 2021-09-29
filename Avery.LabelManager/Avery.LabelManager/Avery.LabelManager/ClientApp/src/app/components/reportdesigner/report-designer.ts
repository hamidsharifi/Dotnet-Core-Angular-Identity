import { Component, Inject, ViewEncapsulation } from '@angular/core';
import 'devexpress-reporting/dx-richedit';

@Component({
  selector: 'report-designer',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './report-designer.html',
})

export class ReportDesignerComponent {
  getDesignerModelAction = "api/ReportDesigner/GetReportDesignerModel";
    reportUrl = "Numeric1SideTab";

  constructor(@Inject('BASE_URL') public hostUrl: string) { }
}
