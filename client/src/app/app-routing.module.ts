import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';

//lazy loading done for shop module. Previously we needed to import shopmodule in appmodule, but by doing lazy loading the shop module is loaded only when called and by shopmodule itselg.
const routes: Routes = [
  { path:'' , component : HomeComponent},
  { path:'test-error' , component : TestErrorComponent},
  { path:'server-error' , component : ServerErrorComponent},
  { path:'not-found' , component : NotFoundComponent},
  { path:'shop', loadChildren: () => import('./shop/shop.module').then(mod=>mod.ShopModule) },//lazyloading
  {path:'**', redirectTo:'', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
