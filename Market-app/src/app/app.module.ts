import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './Components/home/home.component';
import { ClientComponent } from './Components/client/client.component';
import { HeaderComponent } from './Components/header/header.component';
import { ProductComponent } from './Components/product/product.component';
import { SaleComponent } from './Components/sale/sale.component';
import { HttpClientModule } from '@angular/common/http';
import { ClientDialogComponent } from './Components/client-dialog/client-dialog.component';
import { FormsModule } from '@angular/forms';
import { DeleteClientDialogComponent } from './Components/delete-client-dialog/delete-client-dialog.component';
import { DeleteProductDialogComponent } from './Components/delete-product-dialog/delete-product-dialog.component';
import { ProductDialogComponent } from './Components/product-dialog/product-dialog.component';
import { FooterComponent } from './Components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ClientComponent,
    HeaderComponent,
    ProductComponent,
    SaleComponent,
    ClientDialogComponent,
    DeleteClientDialogComponent,
    DeleteProductDialogComponent,
    ProductDialogComponent,
    FooterComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
