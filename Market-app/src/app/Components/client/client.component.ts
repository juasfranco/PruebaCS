import { Component, OnInit } from '@angular/core';
import { ApiClientService } from 'src/app/Services/api-client.service';
import { Response } from 'src/app/Models/response';
import { ClientDialogComponent } from '../client-dialog/client-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { Client } from 'src/app/Models/client';
import { DeleteClientDialogComponent } from '../delete-client-dialog/delete-client-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  public clientList: any[] | undefined;
  readonly width: string = '500px';
  constructor(
    private apiClient: ApiClientService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.getClients();
  }
  getClients() {
    this.apiClient.getClient().subscribe(response => {
      this.clientList = response.data;
    });
  }
  openAdd() {
    const dialogRef = this.dialog.open(ClientDialogComponent, {
      width: this.width
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getClients();
    });
  }
  openEdit(client: Client) {
    const dialogRef = this.dialog.open(ClientDialogComponent, {
      width: this.width,
      data: client
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getClients();
    });
  }
  delete(client: Client) {
    const dialogRef = this.dialog.open(DeleteClientDialogComponent, {
      width: this.width
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.apiClient.deleteClient(client.id).subscribe(response => {
          if (response.success === 1) {
            this.snackBar.open('El cliente se ha eliminado', '', { duration: 2000 })
            this.getClients();
          }
        })
      }
    });
  }
}
