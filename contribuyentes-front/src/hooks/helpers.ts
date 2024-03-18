import axios from 'axios';

export type Contribuyente = {
  rncCedula: string;
  nombre: string;
  tipo: string;
  estatus: string;
};

export type ComprobantesFiscales = {
  id: number;
  rncCedula: string;
  ncf: string;
  monto: number;
  itbis18: number;
};

export const getAllContribuyentes = async () => {
  return await axios
    .request<Contribuyente[]>({
      method: 'GET',
      url: 'https://localhost:8080/api/Contribuyentes',
    })
    .then((response) => response.data);
};

export const getComprobantesFiscalesByRncCedula = async (rncCedula: string) => {
  return await axios
    .request<ComprobantesFiscales[]>({
      method: 'GET',
      url: `https://localhost:8080/api/ComprobantesFiscales/${rncCedula}`,
    })
    .then((response) => response.data);
};

export const getMontoTotalComprobantesFiscalesByRncCedula = async (
  rncCedula: string
) => {
  return axios.request({
    method: 'GET',
    url: `https://localhost:8080/api/ComprobantesFiscales/TotalMonto/${rncCedula}`,
  });
};
