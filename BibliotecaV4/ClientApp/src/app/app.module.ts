import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LibrosComponent } from './libros/libros.component';
import { LibrosService } from './libros/libros.service';
import { LibrosFormComponent } from './libros/libros-form/libros-form.component';
import { AutoresComponent } from './autores/autores.component';
import { AutoresFormComponent } from './autores/autores-form/autores-form.component';
import { AutoresService } from './autores/autores.service';
import { CategoriaComponent } from './categoria/categoria.component';
import { CategoriasFormComponent } from './categoria/categorias-form/categorias-form.component';
import { CategoriasService } from './categoria/categorias.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LibrosComponent,
    LibrosFormComponent,
    AutoresComponent,
    AutoresFormComponent,
    CategoriaComponent,
    CategoriasFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'libros', component: LibrosComponent },
      { path: 'libros-agregar', component: LibrosFormComponent },
      { path: 'libros-editar/:id', component: LibrosFormComponent },
      { path: 'autores', component: AutoresComponent },
      { path: 'autores-agregar', component: AutoresFormComponent },
      { path: 'autores-editar/:id', component: AutoresFormComponent },
      { path: 'categorias', component: CategoriaComponent },
      { path: 'categorias-agregar', component: CategoriasFormComponent },
      { path: 'categorias-editar/:id', component: CategoriasFormComponent },
    ])
  ],
  providers: [LibrosService, AutoresService, CategoriasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
