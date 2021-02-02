import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Client } from 'src/app/Models/client';
import { ApiClientService } from 'src/app/Services/api-client.service';

@Component({
  selector: 'app-client-dialog',
  templateUrl: './client-dialog.component.html',
  styleUrls: ['./client-dialog.component.css']
})
export class ClientDialogComponent {
  public id!: number;
  public name!: string;
  public email!: string;
  public address!: string;
  public phone!: string;
  constructor(
    public dialogRef: MatDialogRef<ClientDialogComponent>,
    public apiClient: ApiClientService,
    public snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public client: Client) {
    if (this.client !== null) {
      this.id = client.id;
      this.name = client.clientName;
      this.email = client.clientEmail;
      this.address = client.clientAddress;
      this.phone = client.clientPhone;
    }
  }

  closeDialog() {
    this.dialogRef.close();
  }

  editClient() {
    const client: Client = { id: this.id, clientName: this.name, clientEmail: this.email, clientAddress: this.address, clientPhone: this.phone, clientStatus: true };
    this.apiClient.editClient(client).subscribe(response => {
      if (response.success === 1) {
        this.dialogRef.close();
        this.snackBar.open('El Cliente se editó correctamente.', '', { duration: 2000 });
      }
    });
  }

  addClient() {
    const client: Client = { id: this.id, clientName: this.name, clientEmail: this.email, clientAddress: this.address, clientPhone: this.phone, clientStatus: true };
    this.apiClient.addClient(client).subscribe(response => {
      console.log(response.success);
      if (response.success === 1) {
        this.dialogRef.close();
        this.snackBar.open('El Cliente se insertó correctamente.', '', { duration: 2000 });
      }
    });
  }
}
