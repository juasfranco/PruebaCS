import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Product } from 'src/app/Models/product';
import { ApiProductService } from 'src/app/Services/api-product.service';

@Component({
  selector: 'app-product-dialog',
  templateUrl: './product-dialog.component.html',
  styleUrls: ['./product-dialog.component.css']
})
export class ProductDialogComponent {
  public id!: number;
  public name!: string;
  public unitValue!: number;
  public finalCost!: number;
  public stock!: number;
  constructor(
    public dialogRef: MatDialogRef<ProductDialogComponent>,
    public apiProduct: ApiProductService,
    public snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public product: Product) {
    if (this.product !== null) {
      this.id = product.id;
      this.name = product.productName;
      this.unitValue = product.productUnitValue;
      this.finalCost = product.productFinalCost;
      this.stock = product.productStock;
    }
  }
  closeDialog() {
    this.dialogRef.close();
  }

  editProduct() {
    const product: Product = { id: this.id, productName: this.name, productUnitValue: this.unitValue, productFinalCost: this.finalCost, productStock: this.stock, productStatus: true };
    this.apiProduct.editProduct(product).subscribe(response => {
      if (response.success === 1) {
        this.dialogRef.close();
        this.snackBar.open('El producto se editó correctamente.', '', { duration: 2000 });
      }
    });
  }

  addProduct() {
    const product: Product = { id: this.id, productName: this.name, productUnitValue: this.unitValue, productFinalCost: this.finalCost, productStock: this.stock, productStatus: true };
    this.apiProduct.addProduct(product).subscribe(response => {
      console.log(response.success);
      if (response.success === 1) {
        this.dialogRef.close();
        this.snackBar.open('El producto se insertó correctamente.', '', { duration: 2000 });
      }
    });

  }
}
