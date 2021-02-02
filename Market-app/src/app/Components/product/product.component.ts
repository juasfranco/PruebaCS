import { Component, OnInit } from '@angular/core';
import { ApiProductService } from 'src/app/Services/api-product.service';
import { Response } from 'src/app/Models/response';
import { ProductDialogComponent } from '../product-dialog/product-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Product } from 'src/app/Models/product';
import { DeleteProductDialogComponent } from '../delete-product-dialog/delete-product-dialog.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  public productList: any[] | undefined;
  readonly width: string = '500px';
  constructor(
    private apiProduct: ApiProductService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.apiProduct.getProduct().subscribe(response => {
      this.productList = response.data;
    });
  }
  openAdd() {
    const dialogRef = this.dialog.open(ProductDialogComponent, {
      width: this.width
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getProducts();
    });
  }
  openEdit(product: Product) {
    const dialogRef = this.dialog.open(ProductDialogComponent, {
      width: this.width,
      data: product
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getProducts();
    });
  }
  delete(product: Product) {
    const dialogRef = this.dialog.open(DeleteProductDialogComponent, {
      width: this.width
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.apiProduct.deleteProduct(product.id).subscribe(response => {
          if (response.success === 1) {
            this.snackBar.open('El Producto se ha eliminado', '', { duration: 2000 })
            this.getProducts();
          }
        })
      }
    });
  }

}
