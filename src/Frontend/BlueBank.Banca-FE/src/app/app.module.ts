import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AcountNewComponent } from './acountnew/acountnew.component';
import { AcountMoveComponent } from './acountmove/acountmove.component';
import { AcountGetComponent } from './acountget/acountget.component';
import { CustomerComponent } from './customer/customer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AcountNewComponent,
    AcountMoveComponent,
    AcountGetComponent,
    CustomerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'acountnew', component: AcountNewComponent },
      { path: 'acountmove', component: AcountMoveComponent },
      { path: 'acountget', component: AcountGetComponent },
      { path: 'customer', component: CustomerComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
