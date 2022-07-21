import { Component, OnInit } from '@angular/core';
import { CalculatorService } from 'src/services/calculator.service';
import { IInputData } from '../../model/InputData';

@Component({
  selector: 'app-calculatorform',
  templateUrl: './calculatorform.component.html',
  styleUrls: ['./calculatorform.component.css']
})
export class CalculatorformComponent implements OnInit {

  
  allOperations : string[] = ["Add","Subtract","Multiply","Divide","Other"];
  selectedOperation : string = "Add";
  result : string = "" ;
  isLoading : boolean = false ;
  isLoadingText : string = "";

  input : IInputData = {
    start: 0,
    amountOrBy: 0
  }  ;


  constructor(private calculatorService : CalculatorService ) { }

  ngOnInit() {
  }

  calculate(){
     this.isLoadingText = "Pls wait, system logging to Database";
     switch(this.selectedOperation)
     {
        case "Add": { 
            this.calculatorService.add(this.input).subscribe((response : string)=>{
            this.isLoadingText="";
            this.result = response ;
          })
          break; 
        } 
        case "Subtract": { 
          this.calculatorService.subtract(this.input).subscribe((response : string)=>{
            this.isLoadingText="";
            this.result = response ;
        })
        break; 
       } 
       case "Multiply": { 
        this.calculatorService.multiply(this.input).subscribe((response : string)=>{
          this.isLoadingText="";
          this.result = response ;
      })
      break; 
     } 
     case "Divide": { 
      this.calculatorService.divide(this.input).subscribe((response : string)=>{
      this.isLoadingText="";
      this.result = response ;
    })
    break; 
   } 

      default: { 

          this.result = "Invalid choice" ;
          break;              
      }
     }
   
  }



}
