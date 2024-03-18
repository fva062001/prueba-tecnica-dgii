"use client";
import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import { ReactQueryDevtools } from 'react-query/devtools'
import { QueryClient } from "react-query";
import { QueryClientProvider } from "react-query";
import Navbar from "@/components/NavBar";

const queryClient = new QueryClient();

const inter = Inter({ subsets: ["latin"] });


export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <QueryClientProvider client={queryClient}>
        <Navbar />
        {children}
        <ReactQueryDevtools initialIsOpen={false} />
        </QueryClientProvider>
        </body>
    </html>
  );
}
