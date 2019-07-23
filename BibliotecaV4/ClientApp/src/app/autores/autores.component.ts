import { Component, OnInit } from '@angular/core';
import { IAutor } from './autor';
import { AutoresService } from './autores.service';

@Component({
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styleUrls: ['./autores.component.css']
})
export class AutoresComponent implements OnInit {

  autores: IAutor[];


  constructor(private autoresService: AutoresService) { }

  ngOnInit() {
    this.cargarData();

  }


  delete(autor: IAutor) {
    this.autoresService.deleteAutor(autor.idAutor.toString())
      .subscribe(autor => this.cargarData(),
        error => console.error(error));
  }

  cargarData() {
    this.autoresService.GetAutores()
      .subscribe(autoresDesdeWS => this.autores = autoresDesdeWS,
        error => console.error(error));
  }
}
