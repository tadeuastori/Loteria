import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RegistrarApostaComponent } from './registraraposta/registraraposta.component';
import { SortearResultadoComponent } from './sortearresultado/sortearresultado.component';
import { ListarApostaComponent } from './listaraposta/listaraposta.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RegistrarApostaComponent,
    SortearResultadoComponent,
    ListarApostaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: RegistrarApostaComponent, pathMatch: 'full' },
      { path: 'sortearresultado', component: SortearResultadoComponent },
      { path: 'listaraposta', component: ListarApostaComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
