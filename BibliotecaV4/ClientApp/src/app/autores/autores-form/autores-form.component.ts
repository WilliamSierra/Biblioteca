import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IAutor } from '../autor';
import { AutoresService } from '../autores.service';
import { Router, ActivatedRoute } from '@angular/router';
import { error } from 'protractor';

@Component({
  selector: 'app-autores-form',
  templateUrl: './autores-form.component.html',
  styleUrls: ['./autores-form.component.css']
})
export class AutoresFormComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private autoresService: AutoresService,
    private router: Router,
    private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  formGroup: FormGroup;
  autorId: number;

  ngOnInit() {
    this.formGroup = this.fb.group({
      nombre: '',
      apellido: '',
      fechaNacimiento: ''
    });

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        //console.log(params["idAutor"]);
        //console.log("f");
        return;
      }
      this.modoEdicion = true;

      this.autorId = params["id"];
      console.log(this.autorId);

      this.autoresService.getAutor(this.autorId.toString())
        .subscribe(autor => this.cargarFormulario(autor),
          error => console.error(error));

    });
  }

  cargarFormulario(autor: IAutor) {
    this.formGroup.patchValue({
      idAutor: autor.idAutor,
      nombre: autor.nombre,
      apellido: autor.apellido,
      fechaNacimiento: autor.fechaNacimiento
    })
  }

  save() {
    let autor: IAutor = Object.assign({}, this.formGroup.value);
    console.table(autor);

    if (this.modoEdicion) {
      autor.idAutor = this.autorId;
      this.autoresService.updateAutor(autor)
        .subscribe(autor => this.onSaveSucces(),
          error => console.error(error));
    } else {

    }

    this.autoresService.createAutor(autor)
      .subscribe(autor => this.onSaveSucces(),
        error => console.error(error));
  }

  onSaveSucces() {
    this.router.navigate(["/autores"])
  }

}
