import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-client-dialog',
  templateUrl: './delete-client-dialog.component.html',
  styleUrls: ['./delete-client-dialog.component.css']
})
export class DeleteClientDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DeleteClientDialogComponent>) { }

  ngOnInit(): void {
  }

}
