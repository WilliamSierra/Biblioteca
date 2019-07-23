import { Component, OnInit } from '@angular/core';
import { ILibro } from './libro';
import { LibrosService } from './libros.service';

@Component({
  selector: 'app-libros',
  templateUrl: './libros.component.html',
  styleUrls: ['./libros.component.css']
})
export class LibrosComponent implements OnInit {

  libros: ILibro[];
  

  constructor(private librosService: LibrosService) { }

  ngOnInit() {
    this.cargarData();

  }

  delete(libro: ILibro) {
    this.librosService.deleteLibro(libro.id.toString())
      .subscribe(libro => this.cargarData(),
        error => console.error(error));
  }

  cargarData() {
    this.librosService.GetLibros()
      .subscribe(librosDesdeWS => this.libros = librosDesdeWS,
        error => console.error(error));
  }
}
