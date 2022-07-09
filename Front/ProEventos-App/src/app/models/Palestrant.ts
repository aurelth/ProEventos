import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrant {
  id: number;
  nome: string;
  miniCurriculo: number;
  imagemURL: string;
  telefone: string;
  email: string;
  redesSociais: RedeSocial[];
  palestrantEventos: Evento[];
}
