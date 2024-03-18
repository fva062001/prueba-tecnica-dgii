import React from 'react';
import { useRouter } from 'next/navigation';

const Navbar = () => {
    const router = useRouter();
  return (
    <nav className='bg-[#333] px-10 py-3'>
      <div className='text-white hover:text-[#555]' onClick={() => {
        router.push("/");
      }}>Home</div>
    </nav>
  );
};

export default Navbar;
