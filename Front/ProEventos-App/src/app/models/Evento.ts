import { Lot } from './Lot';
import { Palestrant } from './Palestrant';
import { RedeSocial } from './RedeSocial';

export interface Evento {
  id: number;
  local: string;
  dataEvento?: Date;
  tema: string;
  qtdPessoas: number;
  imageURL: string;
  telefone: string;
  email: string;
  lots: Lot[];
  redeSociais: RedeSocial[];
  palestrantEventos: Palestrant[];
}
