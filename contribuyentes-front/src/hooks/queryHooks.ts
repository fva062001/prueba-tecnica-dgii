import { useQuery } from "react-query";
import { getAllContribuyentes, getComprobantesFiscalesByRncCedula, getMontoTotalComprobantesFiscalesByRncCedula } from "./helpers"

export const useGetContribuyentes = () => {
    return useQuery({
        queryKey: "contribuyentes",
        queryFn: getAllContribuyentes,
        keepPreviousData: false,
    })
}

export const useGetComprobantesFiscalesByRncCedula = (rncCedula: string) => {
    return useQuery({
        queryKey: ["comprobantesFiscales", rncCedula],
        queryFn: () => getComprobantesFiscalesByRncCedula(rncCedula),
        keepPreviousData: false,
        
    })
}

export const useGetMontoTotalComprobantesFiscalesByRncCedula = (rncCedula: string) => {
    return useQuery({
        queryKey: ["montoTotalComprobantesFiscales", rncCedula],
        queryFn: () => getMontoTotalComprobantesFiscalesByRncCedula(rncCedula),
        keepPreviousData: false,
    })
}

