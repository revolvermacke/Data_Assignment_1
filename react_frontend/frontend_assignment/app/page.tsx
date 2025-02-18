import Link from "next/link";
import Products from "@/components/products";

export default function Home() {
  return (
    <>
      <div className="h-screen flex flex-col items-center justify-center gap-8 p-6">
        <h2 className="text-4xl font-semibold">Welcome</h2>

        <nav className="flex gap-4">
          <Link
            href="/projects"
            className="text-black-500 border-2 rounded-sm p-2 border-black bg-primary text-primary-foreground hover:bg-primary/90"
          >
            All Projects
          </Link>
          <Link
            href="/AddProject"
            className="text-black-500 border-2 rounded-sm p-2 border-black bg-primary text-primary-foreground hover:bg-primary/90"
          >
            Add New Project
          </Link>
          <Link
            href="/AddCustomer"
            className="text-black-500 border-2 rounded-sm p-2 border-black bg-primary text-primary-foreground hover:bg-primary/90"
          >
            Add New Customer
          </Link>
        </nav>
      </div>
      <Products />
    </>
  );
}
