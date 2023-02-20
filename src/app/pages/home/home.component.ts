import { Component, OnInit } from '@angular/core';
import { UsuariosService } from 'src/app/services/usuarios.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})  
export class HomeComponent implements OnInit {
  public mostrarUsuarios: boolean = false;
  public UsuariosList: any = [];

  constructor(private usuariosService: UsuariosService) { }

  ngOnInit(): void {
    this.refreshDepList();
  }

  refreshDepList() {
    this.usuariosService.getUsuarios().subscribe(data => {
      this.UsuariosList = data;
      console.log(data)
    });
  }

  showUsers() {
    this.mostrarUsuarios = !this.mostrarUsuarios;
  }
}
