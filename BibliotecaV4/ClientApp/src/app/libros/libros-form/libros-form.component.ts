import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ILibro } from '../libro';
import { LibrosService } from '../libros.service';
import { Router, ActivatedRoute } from '@angular/router';
import { error } from 'protractor';

@Component({
  selector: 'app-libros-form',
  templateUrl: './libros-form.component.html',
  styleUrls: ['./libros-form.component.css']
})
export class LibrosFormComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private librosService: LibrosService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  formGroup: FormGroup;
  libroId: number;

  ngOnInit() {
    this.formGroup = this.fb.group({
      nombre: '',
      autorId: '',
      categoriaId: '',
      isbn: ''
    });

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }
      this.modoEdicion = true;

      this.libroId = params["id"];

      this.librosService.getLibro(this.libroId.toString())
        .subscribe(libro => this.cargarFormulario(libro),
          error => console.error(error));

    });
  }

  cargarFormulario(libro: ILibro) {
    this.formGroup.patchValue({
      nombre: libro.nombre,
      autorId: libro.autorId,
      categoriaId: libro.categoriaId,
      isbn: libro.isbn
    })
  }

  save() {
    let libro: ILibro = Object.assign({}, this.formGroup.value);
    console.table(libro);

    if (this.modoEdicion) {
      libro.id = this.libroId;
      this.librosService.updateLibro(libro)
        .subscribe(libro => this.onSaveSucces(),
          error => console.error(error));
    } else {

    }

    this.librosService.createLibro(libro)
      .subscribe(libro => this.onSaveSucces(),
        error => console.error(error));
  }

  onSaveSucces() {
    this.router.navigate(["/libros"])
  }

}
