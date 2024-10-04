import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PessoasComponent } from './components/pessoas/pessoas.component';
import { TestComponent } from './components/test/test.component';

const routes: Routes = [
  { path: '', component: PessoasComponent },
  { path: 'test', component: TestComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
