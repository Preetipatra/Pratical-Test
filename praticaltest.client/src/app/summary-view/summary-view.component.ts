
import { Component, OnInit } from '@angular/core';
import { DataService } from '../_services/data.service';

@Component({
  selector: 'app-summary-view',
  templateUrl: './summary-view.component.html',
  styleUrls: ['./summary-view.component.css']
})
export class SummaryViewComponent implements OnInit {
  data: any;
  errorMessage: string | null = null;

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.dataService.getData().subscribe(
      (response : any) => {
        this.data = response;
      },
      (error :any) => {
        this.errorMessage = 'Failed to fetch data: ' + error.message;
        console.error(error);
      }
    );
  }


    // Method to get the value of a property by its label
    getPropertyValue(properties: any[], label: string): any {
      console.log('properties',properties)
      const property = properties.find((prop) => prop.label === label);
      return property ? property.value : ''; 
    }

}
