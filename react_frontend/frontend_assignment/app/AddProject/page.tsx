"use client";

import Link from "next/link";
import AddProject from "@/components/AddProject";

const AboutPage = () => {
  return (
    <>
      <div className="min-h-screen flex flex-col items-center justify-center bg-gray-50 p-4">
        <Link
          className="text-2xl mb-10 border-2 rounded-sm p-1 border-black bg-primary text-primary-foreground hover:bg-primary/90"
          href="/"
        >
          Go Back
        </Link>
        <div className="max-w-md w-full mx-auto text-center">
          <h1 className="text-2xl font-bold mb-4 underline">New Project</h1>
          <AddProject />
        </div>
      </div>
    </>
  );
};

export default AboutPage;
