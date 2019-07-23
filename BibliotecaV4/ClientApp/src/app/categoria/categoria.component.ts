import { Component, OnInit } from '@angular/core';
import { ICategoria } from './categoria';
import { CategoriasService } from './categorias.service';

@Component({
  selector: 'app-categorias',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {

  categorias: ICategoria[];


  constructor(private categoriasService: CategoriasService) { }

  ngOnInit() {
    this.cargarData();

  }

  delete(categoria: ICategoria) {
    this.categoriasService.deleteCategoria(categoria.id.toString())
      .subscribe(categoria => this.cargarData(),
        error => console.error(error));
  }

  cargarData() {
    this.categoriasService.GetCategorias()
      .subscribe(categoriasDesdeWS => this.categorias = categoriasDesdeWS,
        error => console.error(error));
  }
}
