import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../_services/data.service';

@Component({
  selector: 'app-detailed-view',
  templateUrl: './detailed-view.component.html',
  styleUrls: ['./detailed-view.component.css']
})
export class DetailedViewComponent implements OnInit {
  data: any = { Datas: [] }; // Holds the fetched data
  form!: FormGroup; // Reactive form instance
  selectedIndex = 0; // Default selected index

  constructor(private fb: FormBuilder, private http: HttpClient,private dataService: DataService) {}

  ngOnInit(): void {
    // Initialize the form
    this.form = this.fb.group({
      projectName: [''],
      constructionCount: [''],
      isCompleted: [false],
      roadLength: ['']
    });

    // Fetch the data via API call
    this.getData();
  }

  // Fetch data from the API
  getData(): void {
    this.dataService.getData().subscribe(
      (response) => {
        this.data = response; // Assign fetched data
        if (this.data.datas.length > 0) {
          this.populateForm(this.data.datas[this.selectedIndex]); // Populate form with the first date's data
        }
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

  // Populate the form based on the selected date
  populateForm(selectedData: any): void {
    const properties = selectedData.properties;

    const projectName = this.getPropertyValue(properties, 'Project Name');
    const constructionCount = this.getPropertyValue(properties, 'Construction Count');
    const isCompleted = this.getPropertyValue(properties, 'Is Construction Completed');
    const roadLength = this.getPropertyValue(properties, 'Length of the road');

    this.form.patchValue({
      projectName: projectName ?? '',
      constructionCount: constructionCount ?? '',
      isCompleted: isCompleted ?? false,
      roadLength: roadLength ?? ''
    });
  }

  // Handle date selection
  onDateSelect(selectedData: any, index: number): void {
    this.selectedIndex = index;
    this.populateForm(selectedData);
  }

  // Get the value of a property by its label
  getPropertyValue(properties: any[], label: string): any {
    const property = properties.find((prop) => prop.label === label);
    return property ? property.value : null;
  }

  // Format date for display in the list
  formatDateString(dateString: string): string {
    const date = new Date(dateString);
    return date.toLocaleString('en-GB', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit',
      hour12: true
    });
  }

  // Save the updated data
  onSubmit(): void {
    const updatedData = {
      id: 1, 
      name: 'New Observation', 
      datas: [
        {
          samplingTime: this.data.datas[this.selectedIndex].samplingTime, // Retain the sampling time
          properties: [
            { label: 'Project Name', value: this.form.value.projectName },
            { label: 'Construction Count', value: this.form.value.constructionCount },
            { label: 'Is Construction Completed', value: this.form.value.isCompleted },
            { label: 'Length of the road', value: this.form.value.roadLength }
          ]
        }
      ]
    };

    // Call the API to update the data
    this.dataService.saveData(updatedData).subscribe(
      (response) => {
        console.log('Data updated successfully:', response);
        alert('Data updated successfully!');
      },
      (error) => {
        console.error('Error updating data:', error);
        alert('Failed to update data!');
      }
    );
  }
}
