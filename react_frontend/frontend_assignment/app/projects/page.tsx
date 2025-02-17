import React from "react";
import Link from "next/link";
import AllProjects from "@/components/AllProjects";

const ContactPage = () => {
  return (
    <>
      <div className="h-screen flex-col text-center justify-center p-8">
        <Link
          className="text-2xl mb-10 border-2 rounded-sm p-1 border-black bg-primary text-primary-foreground hover:bg-primary/90"
          href="/"
        >
          Go Back{" "}
        </Link>
        <div className="underline font-bold mt-4">All Projects</div>
        <AllProjects />
      </div>
    </>
  );
};

export default ContactPage;
