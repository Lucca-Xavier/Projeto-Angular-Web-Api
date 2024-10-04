import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module'; // Certifique-se de que está importando corretamente
import { AppComponent } from './app.component';
import { PessoasComponent } from './components/pessoas/pessoas.component';
import { TestComponent } from './components/test/test.component';

@NgModule({
  declarations: [
    AppComponent,
    PessoasComponent,
    TestComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, // Importação do módulo de roteamento
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
