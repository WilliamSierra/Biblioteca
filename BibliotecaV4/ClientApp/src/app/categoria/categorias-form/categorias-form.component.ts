import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ICategoria } from '../categoria';
import { CategoriasService } from '../categorias.service';
import { Router, ActivatedRoute } from '@angular/router';
import { error } from 'protractor';

@Component({
  selector: 'app-categorias-form',
  templateUrl: './categorias-form.component.html',
  styleUrls: ['./categorias-form.component.css']
})
export class CategoriasFormComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private categoriasService: CategoriasService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  formGroup: FormGroup;
  categoriaId: number;

  ngOnInit() {
    this.formGroup = this.fb.group({
      nombre: '',
      descripcion: ''
    });

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }
      this.modoEdicion = true;

      this.categoriaId = params["id"];

      this.categoriasService.getCategoria(this.categoriaId.toString())
        .subscribe(categoria => this.cargarFormulario(categoria),
          error => console.error(error));

    });
  }

  cargarFormulario(categoria: ICategoria) {
    this.formGroup.patchValue({
      nombre: categoria.nombre,
      descripcion: categoria.descripcion
    })
  }

  save() {
    let categoria: ICategoria = Object.assign({}, this.formGroup.value);
    console.table(categoria);

    if (this.modoEdicion) {
      categoria.id = this.categoriaId;
      this.categoriasService.updateCategoria(categoria)
        .subscribe(categoria => this.onSaveSucces(),
          error => console.error(error));
    } else {

    }

    this.categoriasService.createCategoria(categoria)
      .subscribe(categoria => this.onSaveSucces(),
        error => console.error(error));
  }

  onSaveSucces() {
    this.router.navigate(["/categorias"])
  }

}
