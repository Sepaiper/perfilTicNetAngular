import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorsService } from '../../common/validators.service';
import { LoginService } from 'src/app/services/login.service';
import { lastValueFrom } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  typePassword: string = 'password';
  showPasswordIcon: boolean = true;
  constructor(
    private loginServices: LoginService,
    private fb: FormBuilder,
    private validatorService: ValidatorsService,
    private router: Router,
  ) { }

  public datalogin: FormGroup = this.fb.group({
    email: [null, [Validators.required, Validators.maxLength(110), Validators.pattern(this.validatorService.emailPattern)]],
    password: [null, [Validators.required, Validators.maxLength(100), Validators.pattern(this.validatorService.passwordPattern)]]
  })

  get emailErrorsMsg(): string {
    const errors = this.datalogin.get('email')?.errors;
    if (errors?.['required']) return 'El email es requerido';
    if (errors?.['maxlength']) return 'El email tiene un maximo de caracteres de 100';
    if (errors?.['pattern']) return 'El email debe ser xx@xx.com';
    return '';
  }

  get passwordErrorsMsg(): string {
    const errors = this.datalogin.get('password')?.errors;
    if (errors?.['required']) return 'El password es requerido';
    if (errors?.['maxlength']) return 'El password tiene un maximo de caracteres de 100';
    if (errors?.['pattern']) return 'El password no debe tener caracteres especiales';
    return '';
  }

  ngOnInit(): void {
  }

  async login() {
    if (this.datalogin.invalid) {
      this.datalogin.markAllAsTouched();
      return;
    }
    const data = {
      email: this.datalogin.get('email')?.value,
      password: this.datalogin.get('password')?.value,
    };
    const response = await lastValueFrom(await this.loginServices.loginRequest(data));
    if(response.token){
      localStorage.setItem('token', response.token);
      sessionStorage.setItem('token', response.token);
      this.router.navigate([`home/${response.token}`]);
    }
  }

  camposNoValidos(campo: string) {
    return this.datalogin.get(campo)?.invalid
      && this.datalogin.get(campo)?.touched;
  }

  showPassword() {
    this.showPasswordIcon = !this.showPasswordIcon;
    if (this.showPasswordIcon) {
      this.typePassword = 'password'
    } else {
      this.typePassword = 'text'
    }
  }

}
