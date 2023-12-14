using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly CampusShopContext _context;
    public UnitOfWork(CampusShopContext context)
    {
        _context = context;
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    private ICarritoCompra _carritocompras;
    private ICategoriaProducto _categoriaproductos;
    private ICliente _clientes;
    private IClienteCompra _clientecompras;
    private ICompra _compras;
    private IDetalleProducto _detalleproductos;
    private IPago _pagos;
    private IProducto _productos;
    private IRol _rols;
    private IUser _usuarios;
    private IUsuarioRoles _usuarioroless;
    public ICarritoCompra CarritoCompras {
        get
        {
            if(_carritocompras == null) 
            {
                _carritocompras = new CarritoCompraRepository(_context);
            }
            return _carritocompras;
        }
    }
    public ICategoriaProducto CategoriaProductos {
        get
        {
            if(_categoriaproductos == null) 
            {
                _categoriaproductos = new CategoriaProductoRepository(_context);
            }
            return _categoriaproductos;
        }
    }
    public ICliente Clientes {
        get
        {
            if(_clientes == null) 
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }
    public IClienteCompra ClienteCompras {
        get
        {
            if(_clientecompras == null) 
            {
                _clientecompras = new ClienteCompraRepository(_context);
            }
            return _clientecompras;
        }
    }
    public ICompra Compras {
        get
        {
            if(_compras == null) 
            {
                _compras = new CompraRepository(_context);
            }
            return _compras;
        }
    }
    public IDetalleProducto DetalleProductos {
        get
        {
            if(_detalleproductos == null) 
            {
                _detalleproductos = new DetalleProductoRepository(_context);
            }
            return _detalleproductos;
        }
    }
    public IPago Pagos {
        get
        {
            if(_pagos == null) 
            {
                _pagos = new PagoRepository(_context);
            }
            return _pagos;
        }
    }
    public IProducto Productos {
        get
        {
            if(_productos == null) 
            {
                _productos = new ProductoRepository(_context);
            }
            return _productos;
        }
    }
    public IRol Roles {
        get
        {
            if(_rols == null) 
            {
                _rols = new RolRepository(_context);
            }
            return _rols;
        }
    }
    public IUser Users {
        get
        {
            if(_usuarios == null) 
            {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public IUsuarioRoles UsuarioRoless {
        get
        {
            if(_usuarioroless == null) 
            {
                _usuarioroless = new UsuariosRolesRepository(_context);
            }
            return _usuarioroless;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
