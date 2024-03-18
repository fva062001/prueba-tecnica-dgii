"use client";
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
import { Contribuyente } from "@/hooks/helpers";
import { Button } from "@/components/ui/button"
import { useGetContribuyentes } from "@/hooks/queryHooks";
import { useRouter } from "next/navigation";
import ReactLoading from 'react-loading';

export default function Home() {
  const { data: contribuyentes, isLoading:loadingContribuyentes } = useGetContribuyentes();
  const router = useRouter();

  if (loadingContribuyentes) {
    return     <ReactLoading className='absolute top-1/2 -translate-y-1/2 left-1/2 -translate-x-1/2' type={'bubbles'} color={'#333'} height={'5%'} width={'5%'} />

  }

  return (
  <main className="container my-6">
    <h1 className="text-4xl font-bold">Contribuyentes Front</h1>
    <div className="my-2">
  {!loadingContribuyentes &&  <Table>
      <TableCaption>Lista de todos los contribuyentes</TableCaption>
      <TableHeader>
        <TableRow>
          <TableHead className="w-[100px]">RNC/Cédula</TableHead>
          <TableHead>Nombre</TableHead>
          <TableHead>Tipo</TableHead>
          <TableHead>Estado</TableHead>
          <TableHead className="text-right">Acciones</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {contribuyentes && contribuyentes.map((contribuyente:Contribuyente) => (
          <TableRow key={contribuyente.rncCedula}>
            <TableCell className="font-medium">{contribuyente.rncCedula}</TableCell>
            <TableCell>{contribuyente.nombre}</TableCell>
            <TableCell>{contribuyente.tipo}</TableCell>
            <TableCell className="text-right">{contribuyente.estatus}</TableCell>
            <TableCell className="text-right">
              <Button onClick={() => {
                router.push(`/contribuyente/${contribuyente.rncCedula}`)
              }}>Ver Contribuyente</Button>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>}
    </div>
  </main>
  );
}
