"use client";
import React from 'react'
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
  TableFooter
} from "@/components/ui/table"
import { currencyFormat } from '@/utils/pipes';
import { useGetComprobantesFiscalesByRncCedula } from '@/hooks/queryHooks'
import { useGetMontoTotalComprobantesFiscalesByRncCedula } from '@/hooks/queryHooks'
import { useParams } from 'next/navigation'
import { ComprobantesFiscales } from '@/hooks/helpers';
import ReactLoading from 'react-loading';

function ContribuyentePage() {

  const params = useParams();
  const { data:comprobantes, isLoading:loadingComprobantes } = useGetComprobantesFiscalesByRncCedula(params.id.toString());
  const { data:totalMonto, isLoading:loadingTotalMonto } = useGetMontoTotalComprobantesFiscalesByRncCedula(params.id.toString());

  if (loadingComprobantes || loadingTotalMonto) {
    return     <ReactLoading className='absolute top-1/2 -translate-y-1/2 left-1/2 -translate-x-1/2' type={'bubbles'} color={'#333'} height={'5%'} width={'5%'} />

  }


  return (
    <main className="container my-6">
      <h1 className="text-4xl font-bold">Comprobantes Fiscales {params.id}</h1>
      <Table>
      <TableCaption>Lista de Comprobantes Fiscales</TableCaption>
      <TableHeader>
        <TableRow>
          <TableHead className="w-[100px]">Id</TableHead>
          <TableHead>RNC/Cedula</TableHead>
          <TableHead>NCF</TableHead>
          <TableHead className="text-right">Monto</TableHead>
          <TableHead className="text-right">ITBIS</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {comprobantes && comprobantes.map((comprobante:ComprobantesFiscales) => (
          <TableRow key={comprobante.id}>
            <TableCell className="font-medium">{comprobante.id}</TableCell>
            <TableCell>{comprobante.rncCedula}</TableCell>
            <TableCell>{comprobante.ncf}</TableCell>
            <TableCell className="text-right">{currencyFormat(comprobante.monto)}</TableCell>
            <TableCell className="text-right">{currencyFormat(comprobante.itbis18)}</TableCell>
          </TableRow>
        ))}
        {!comprobantes && <TableRow>
          <TableCell colSpan={5} className="text-center">No hay comprobantes fiscales</TableCell>
          </TableRow>
          }
      </TableBody>
      <TableFooter>
        <TableRow>
          <TableCell colSpan={4}>Monto Total de Comprobantes</TableCell>
          <TableCell className="text-right">{totalMonto && currencyFormat(totalMonto.data)}</TableCell>
        </TableRow>
      </TableFooter>
    </Table>
    </main>)
}

export default ContribuyentePage