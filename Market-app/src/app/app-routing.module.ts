import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { ClientComponent } from './Components/client/client.component';
import { ProductComponent } from './Components/product/product.component';
import { SaleComponent } from './Components/sale/sale.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'client', component: ClientComponent },
  { path: 'product', component: ProductComponent },
  { path: 'sale', component: SaleComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
