import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailedViewComponent } from './detailed-view/detailed-view.component';
import { SummaryViewComponent } from './summary-view/summary-view.component';

const routes: Routes = [
  {
    path: "",
    component: SummaryViewComponent
  },
  {
    path: "detail-view",
    component: DetailedViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
